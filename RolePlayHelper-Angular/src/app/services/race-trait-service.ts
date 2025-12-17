import { HttpClient, httpResource } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { RaceTraitCreateModel } from '@core/models/raceTrait/race-trait-create-model';
import { RaceTraitList } from '@core/models/raceTrait/race-trait-list.model';
import { environment } from '@env';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class raceTraitService {
  getSomeByName(filter: string) {
    if (filter.length > 0) {
      return firstValueFrom(
        this._httpClient.get<RaceTraitList[]>(
          environment.apiUrl + 'api/Race/RaceListAddCharFiltered',
          { params: { filter: filter } },
        ),
      );
    } else {
      return this.getRaceTraits();
    }
  }
  private readonly _httpClient = inject(HttpClient);

  getRaceTraits(): Promise<RaceTraitList[]> {
    return firstValueFrom(
      this._httpClient.get<RaceTraitList[]>(environment.apiUrl + 'api/RaceTrait'),
    );
  }

  postRaceTrait(raceTrait: RaceTraitCreateModel) {
    return firstValueFrom(
      this._httpClient.post<RaceTraitCreateModel>(environment.apiUrl + 'api/RaceTrait', raceTrait),
    );
  }
}
