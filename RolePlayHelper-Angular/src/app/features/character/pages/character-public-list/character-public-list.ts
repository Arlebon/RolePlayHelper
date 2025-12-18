import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { ListingTable } from '@components/common/listing-table/listing-table';
import { CharClassListModel } from '@core/models/char-class/char-class-list-model';

import { CharacterService } from 'src/app/services/character-service';

@Component({
  selector: 'app-character-public-list',
  imports: [ListingTable],
  templateUrl: './character-public-list.html',
  styleUrl: './character-public-list.scss',
})
export class CharacterPublicList {
  private readonly _characterService = inject(CharacterService);

  constructor(private cdr: ChangeDetectorRef) {}

  characters: CharClassListModel[] = [];

  ngOnInit(): void {
    this._characterService.getCharactersPublic().then((data) => {
      console.log(data);
      this.characters = data;
      this.cdr.markForCheck();
    });
  }
}
