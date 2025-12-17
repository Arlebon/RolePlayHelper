import { HttpClient } from '@angular/common/http';

import { computed, effect, inject, Injectable, signal, Signal } from '@angular/core';
import { UserRole } from '@core/enums';
import { LoginResponse, Token, UserRegisterForm } from '@core/models/authentication-models';

import { environment } from '@env';
import { jwtDecode } from 'jwt-decode';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly _httpClient = inject(HttpClient);

  private _userId = signal<number | null>(null);
  userId = this._userId.asReadonly();

  // signal pour le token JWT
  private _token = signal<string | null>(null);
  token = this._token.asReadonly();

  // signal pour savoir si l'utilisateur est connecté (calculé à partir du token)
  isConnected: Signal<boolean> = computed(() => !!this.token()); // !! convertit en booléen

  // signal pour le role de l'utilisateur (null si non connecté)
  private _role = signal<UserRole | null>(null);
  role = this._role.asReadonly();

  constructor() {
    // Récupération du token depuis le localstorage
    const tokenStr = localStorage.getItem('token');

    if (tokenStr) {
      // S'il y a un token, on le met dans le signal
      this._token.set(tokenStr);
    }

    // Effet qui réagit aux changements du signal "token"
    effect(() => {
      // Récupération de la valeur du token
      const token = this._token();

      if (token == null) {
        // S'il n'y a pas de token, on supprime le token du localstorage et on met le role à null
        // (utilisateur déconnecté)
        localStorage.removeItem('token');
        this._role.set(null);
        this._userId.set(null);
      } else {
        // S'il y a un token, on le stocke dans le localstorage et on met à jour le role
        // (utilisateur connecté)
        localStorage.setItem('token', token);
        const tokenProp = jwtDecode<Token>(token);
        this._role.set(
          tokenProp[
            'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
          ].toLowerCase() as UserRole,
        );

        this._userId.set(
          Number(tokenProp['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid']),
        );
        console.log(tokenProp);
      }
    });
  }

  async login(login: string, password: string): Promise<void> {
    // Appel API pour se connecter
    const response = await firstValueFrom(
      this._httpClient.post<LoginResponse>(environment.apiUrl + 'api/User/login', {
        login,
        password,
      }),
    );
    console.log('loginResponse: ', response.token);

    // Stockage du token dans le signal (ce qui déclenche l'effet)
    this._token.set(response.token);
  }

  register(form: UserRegisterForm): Promise<void> {
    // Appel API pour s'enregistrer
    return firstValueFrom(
      this._httpClient.post<void>(environment.apiUrl + 'api/User/register', form),
    );
  }

  logout() {
    this._token.set(null);
  }
}
