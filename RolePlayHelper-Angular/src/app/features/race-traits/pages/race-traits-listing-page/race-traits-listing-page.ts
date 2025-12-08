import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { ListingTable } from '@components/common/listing-table/listing-table';
import { RaceTraitList } from '@core/models/raceTrait/race-trait-list.model';
import { raceTraitService } from 'src/app/services/race-trait-service';

@Component({
  selector: 'app-race-traits-listing-page',
  imports: [ListingTable],
  templateUrl: './race-traits-listing-page.html',
  styleUrl: './race-traits-listing-page.scss',
})
export class RaceTraitsListingPage {
  _raceTraitService = inject(raceTraitService);

  constructor(private cdr: ChangeDetectorRef) {}

  raceTraits: RaceTraitList[] = [];

  ngOnInit(): void {
    this._raceTraitService.getRaceTraits().then((data) => {
      console.log(data);
      this.raceTraits = data;
      this.cdr.markForCheck();
    });
  }
}
