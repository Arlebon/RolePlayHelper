import { Component, inject } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { readonly } from '@angular/forms/signals';
import { Router } from '@angular/router';
import { ApiError } from '@core/models/authentication-models';

import { AuthService } from 'src/app/services/auth-service';

@Component({
  selector: 'app-login-page',
  imports: [ReactiveFormsModule],
  templateUrl: './login-page.html',
  styleUrl: './login-page.scss',
})
export class LoginPage {
  private readonly _fb = inject(FormBuilder);
  private readonly _authService = inject(AuthService);
  private readonly _router = inject(Router);

  login = new FormControl('', [Validators.required]);
  passWord = new FormControl('', [Validators.required]);

  loginForm = this._fb.group({
    login: this.login,
    password: this.passWord,
  });

  loginError = '';
  async onSubmit() {
    // Vérification de la validité du formulaire
    if (this.loginForm.valid) {
      // formulaire valide, on peut tenter de se connecter
      try {
        await this._authService.login(this.loginForm.value.login!, this.loginForm.value.password!);
        // connexion réussie, redirigé vers la page d'accueil
        this._router.navigate(['/']);
      } catch (err) {
        // connexion échouée, on affiche l'erreur
        console.error(err);
        this.loginError = (err as ApiError).message;
      }
    }
  }
}
