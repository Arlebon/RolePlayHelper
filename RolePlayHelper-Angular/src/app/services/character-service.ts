import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CharClassListModel } from '@core/models/char-class/char-class-list-model';
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

  getCharacters(): Promise<CharClassListModel[]> {
    return firstValueFrom(
      this._httpClient.get<CharClassListModel[]>(
        environment.apiUrl + 'api/Character/List-Characters',
      ),
    );
  }
}
