import { UpperCasePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-listing-table',
  imports: [UpperCasePipe, RouterLink],
  templateUrl: './listing-table.html',
  styleUrl: './listing-table.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
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
