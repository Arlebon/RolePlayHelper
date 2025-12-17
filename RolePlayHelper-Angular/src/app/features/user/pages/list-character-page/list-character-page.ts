import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { CharClassListModel } from '@core/models/char-class/char-class-list-model';
import { LanguageList } from '@core/models/language/language-list.model';
import { CharacterService } from 'src/app/services/character-service';
import { ListingTable } from '@components/common/listing-table/listing-table';

@Component({
  selector: 'app-list-character-page',
  imports: [ListingTable],
  templateUrl: './list-character-page.html',
  styleUrl: './list-character-page.scss',
})
export class ListCharacterPage {
  private readonly _characterService = inject(CharacterService);

  constructor(private cdr: ChangeDetectorRef) {}

  characters: CharClassListModel[] = [];

  ngOnInit(): void {
    this._characterService.getCharacters().then((data) => {
      console.log(data);
      this.characters = data;
      this.cdr.markForCheck();
    });
  }
}
