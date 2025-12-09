import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { CharClassListModel } from '@core/models/char-class/char-class-list-model';
import { CharClassService } from 'src/app/services/char-class-service';
import { ListingTable } from '@components/common/listing-table/listing-table';

@Component({
  selector: 'app-char-class-listing-page',
  imports: [ListingTable],
  templateUrl: './char-class-listing-page.html',
  styleUrl: './char-class-listing-page.scss',
})
export class CharClassListingPage implements OnInit {
  private readonly _charClassService = inject(CharClassService);
  CharClassList: CharClassListModel[] = [];

  constructor(private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this._charClassService.getClasses().then((data) => {
      console.log(data);
      this.CharClassList = data;
      this.cdr.markForCheck();
    });
  }
}
