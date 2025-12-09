import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '403',
    loadComponent: () =>
      import('./pages/forbidden-page/forbidden-page').then((c) => c.ForbiddenPage),
  },
  {
    path: '404',
    loadComponent: () =>
      import('./pages/not-found-page/not-found-page').then((c) => c.NotFoundPage),
  },
  {
    path: '500',
    loadComponent: () => import('./pages/server-error/server-error').then((c) => c.ServerError),
  },
];
