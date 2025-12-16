import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CharacterCreateForm } from '@core/models/character/character-create-form.model';
import { environment } from '@env';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CharacterService {
  private readonly _httpClient = inject(HttpClient);

  createChar(form: CharacterCreateForm) {
    return firstValueFrom(
      this._httpClient.post(environment.apiUrl + 'api/Character/Add-Character', form),
    );
  }
}
