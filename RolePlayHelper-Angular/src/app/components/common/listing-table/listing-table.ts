import { UpperCasePipe } from '@angular/common';
import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-listing-table',
  imports: [UpperCasePipe],
  templateUrl: './listing-table.html',
  styleUrl: './listing-table.scss',
})
export class ListingTable {
  elements = input.required<
    {
      id: number;
      [key: string]: any | null;
    }[]
  >();
  columns = input.required<string[]>();

  clickDetails = output<number>();

  onClickDetails(id: number) {
    this.clickDetails.emit(id);
  }
}
