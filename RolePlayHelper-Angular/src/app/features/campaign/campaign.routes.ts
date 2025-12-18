import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'create-campaign',
    loadComponent: () =>
      import('./pages/create-campaign/create-campaign').then((c) => c.CreateCampaign),
  },
];
