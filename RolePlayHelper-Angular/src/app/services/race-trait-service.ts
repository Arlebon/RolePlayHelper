import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { RaceTraitList } from '@core/models/raceTrait/race-trait-list.model';
import { environment } from '@env';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class raceTraitService {
  private readonly _httpClient = inject(HttpClient);

  getRaceTraits(): Promise<RaceTraitList[]> {
    return firstValueFrom(
      this._httpClient.get<RaceTraitList[]>(environment.apiUrl + 'api/RaceTrait'),
    );
  }
}
