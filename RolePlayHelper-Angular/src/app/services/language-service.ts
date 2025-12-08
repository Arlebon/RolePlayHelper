import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { LanguageList } from '@core/models/language/language-list.model';
import { environment } from '@env';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  private readonly _httpClient = inject(HttpClient);

  getLanguages(): Promise<LanguageList[]> {
    return firstValueFrom(
      this._httpClient.get<LanguageList[]>(environment.apiUrl + 'api/Language'),
    );
  }
}
