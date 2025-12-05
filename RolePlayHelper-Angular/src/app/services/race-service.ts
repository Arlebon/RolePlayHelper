import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '@env';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RaceService {
  private readonly _httpClient = inject(HttpClient);

  getDetails(url: string): Promise<any> {
    return firstValueFrom(this._httpClient.get(environment.apiUrl + url));
  }
}
