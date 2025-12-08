import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'authentication',
    loadChildren: () =>
      import('./features/authentication/authentication.routes').then((r) => r.routes),
  },
  {
    path: 'language',
    loadChildren: () => import('./features/language/language.routes').then((r) => r.routes),
  },
  {
    path: 'raceTrait',
    loadChildren: () => import('./features/race-traits/raceTraits.routes').then((r) => r.routes),
  },
];
