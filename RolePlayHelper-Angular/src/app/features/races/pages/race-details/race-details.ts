import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DetailsPage } from '@components/common/details-page/details-page';

@Component({
  selector: 'app-race-details',
  imports: [],
  templateUrl: './race-details.html',
  styleUrl: './race-details.scss',
})
export class RaceDetails {
  private readonly _activatedRoute = inject(ActivatedRoute);
}
