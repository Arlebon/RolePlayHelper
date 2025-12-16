import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CharClassListCreateChar } from '@core/models/char-class/char-class-list-create-char.model';
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

  getClassesCharCreate(): Promise<CharClassListCreateChar[]> {
    return firstValueFrom(
      this._httpClient.get<CharClassListCreateChar[]>(
        environment.apiUrl + 'api/CharClass/CharClassListAddChar',
      ),
    );
  }

  getOneByIdCharCreate(id: number): Promise<CharClassListCreateChar> {
    return firstValueFrom(
      this._httpClient.get<CharClassListCreateChar>(
        environment.apiUrl + 'api/CharClass/CharClassListAddChar/' + id,
      ),
    );
  }

  getSomeByNameCharCreate(filter: string): Promise<CharClassListCreateChar[]> {
    if (filter.length > 0) {
      return firstValueFrom(
        this._httpClient.get<CharClassListCreateChar[]>(
          environment.apiUrl + 'api/CharClass/CharClassListAddChar',
          { params: { filter: filter } },
        ),
      );
    } else {
      return this.getClassesCharCreate();
    }
  }
}
