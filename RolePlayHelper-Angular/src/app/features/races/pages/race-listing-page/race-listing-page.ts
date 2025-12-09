import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { RaceList } from '@core/models/race/race-list-model';
import { RaceService } from 'src/app/services/race-service';
import { ListingTable } from '@components/common/listing-table/listing-table';
import { RaceListDisplay } from '@core/models/race/race-list-display-model';

@Component({
  selector: 'app-race-listing-page',
  imports: [ListingTable],
  templateUrl: './race-listing-page.html',
  styleUrl: './race-listing-page.scss',
})
export class RaceListingPage implements OnInit {
  private readonly _raceService = inject(RaceService);

  constructor(private cdr: ChangeDetectorRef) {}

  races: RaceListDisplay[] = [];
  ngOnInit(): void {
    this._raceService.getAll().then((data) => {
      this.races = data.map((race) => {
        const stats =
          // Je dois transformer mon Objet statModifier en tableau iterable [[key,value],[key,value]]-->[["str",2],["dex",1]]
          Object.entries(race.statModifier)
            //Maintenant je peux iterer dans les valeur du statmodifer(tableau)
            .filter(([key, value]) => value !== null && value !== 0)
            // je format le statmodifier
            .map(([key, value]) => `${key.toUpperCase()}: ${value}`)
            //je transforme en string, separe par ',' ou just un '-' si stat est vide
            .join(', ') || '-';

        //Je recree un race Object sur base de l'ancien race Object, mais je replace le statmodifer Object par un statmodifier string
        return {
          ...race,
          statModifier: stats,
        };
      });

      console.log(this.races);
      this.cdr.markForCheck();
    });
  }
}
