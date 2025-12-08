import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  inject,
  OnInit,
} from '@angular/core';
import { LanguageList } from '@core/models/language/language-list.model';
import { ListingTable } from '@components/common/listing-table/listing-table';
import { LanguageService } from 'src/app/services/language-service';

@Component({
  selector: 'app-language-list-page',
  imports: [ListingTable],
  templateUrl: './language-list-page.html',
  styleUrl: './language-list-page.scss',
})
export class LanguageListPage implements OnInit {
  private readonly _languageService = inject(LanguageService);

  constructor(private cdr: ChangeDetectorRef) {}

  languages: LanguageList[] = [];

  ngOnInit(): void {
    this._languageService.getLanguages().then((data) => {
      console.log(data);
      this.languages = data;
      this.cdr.markForCheck();
    });
  }
}
