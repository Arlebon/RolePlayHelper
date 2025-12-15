import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { RaceListCreateChar } from '@core/models/race/race-list-create-char.model';
import { RaceList } from '@core/models/race/race-list-model';
import { environment } from '@env';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RaceService {
  private readonly _httpClient = inject(HttpClient);

  getAll() {
    return firstValueFrom(this._httpClient.get<RaceList[]>(environment.apiUrl + 'api/Race'));
  }

  getDetails(url: string): Promise<any> {
    return firstValueFrom(this._httpClient.get(environment.apiUrl + url));
  }

  getAllForCreateChar() {
    return firstValueFrom(
      this._httpClient.get<RaceListCreateChar[]>(environment.apiUrl + 'api/Race/RaceListAddChar'),
    );
  }

  getOneById(id: number) {
    return firstValueFrom(
      this._httpClient.get<RaceListCreateChar>(environment.apiUrl + 'api/Race/' + id),
    );
  }

  getSomeByName(filter: string) {
    if (filter.length > 0) {
      return firstValueFrom(
        this._httpClient.get<RaceListCreateChar[]>(
          environment.apiUrl + 'api/Race/RaceListAddCharFiltered',
          { params: { filter: filter } },
        ),
      );
    } else {
      return this.getAllForCreateChar();
    }
  }
}
