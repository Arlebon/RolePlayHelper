import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { RaceList } from '@core/models/race/race-list-model';
import { environment } from '@env';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RaceService {
  getAll() {
    return firstValueFrom(this._httpClient.get<RaceList[]>(environment.apiUrl + 'api/Race'));
  }
  private readonly _httpClient = inject(HttpClient);

  getDetails(url: string): Promise<any> {
    return firstValueFrom(this._httpClient.get(environment.apiUrl + url));
  }
}
