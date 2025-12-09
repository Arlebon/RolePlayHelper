import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CharClassListModel } from '@core/models/char-class/char-class-list-model';
import { environment } from '@env';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CharClassService {
  private readonly _httpClient = inject(HttpClient);

  getClasses(): Promise<CharClassListModel[]> {
    return firstValueFrom(
      this._httpClient.get<CharClassListModel[]>(environment.apiUrl + 'api/CharClass'),
    );
  }
}
