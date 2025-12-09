import { Routes } from '@angular/router';
import { adminGuard } from '@core/guards/admin-guard';

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
    path: 'race-trait',
    loadChildren: () => import('./features/race-traits/raceTraits.routes').then((r) => r.routes),
  },
  {
    path: 'char-class',
    loadChildren: () => import('./features/charClass/char-class.routes').then((r) => r.routes),
  },
  {
    path: 'race',
    loadChildren: () => import('./features/races/races.routes').then((r) => r.routes),
  },
  {
    path: 'admin',
    canActivateChild: [adminGuard],
    loadChildren: () => import('./features/admin/admin.routes').then((r) => r.routes),
  },
  {
    path: 'error',
    loadChildren: () => import('./features/error/error.routes').then((r) => r.routes),
  },
];
