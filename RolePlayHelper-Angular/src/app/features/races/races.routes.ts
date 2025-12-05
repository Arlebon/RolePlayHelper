import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: ':id',
    loadComponent: () => import('./pages/race-details/race-details').then((c) => c.RaceDetails),
  },
];
