import { NgClass, UpperCasePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-listing-table',
  imports: [UpperCasePipe, RouterLink, NgClass],
  templateUrl: './listing-table.html',
  styleUrl: './listing-table.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ListingTable {
  protected readonly Array = Array;
  elements = input.required<
    {
      id: number;
      [key: string]: any | null;
    }[]
  >();
  columns = input.required<string[]>();
  clickable = input.required<boolean>();
  clickDetails = output<number>();

  onClickDetails(id: number) {
    this.clickDetails.emit(id);
  }
}
