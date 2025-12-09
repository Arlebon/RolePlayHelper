import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/race-traits-listing-page/race-traits-listing-page').then(
        (c) => c.RaceTraitsListingPage,
      ),
  },
];
