import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/race-listing-page/race-listing-page').then((c) => c.RaceListingPage),
  },
  {
    path: ':id',
    loadComponent: () => import('./pages/race-details/race-details').then((c) => c.RaceDetails),
  },
];
