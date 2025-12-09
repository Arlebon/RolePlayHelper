import { inject } from '@angular/core';
import { CanActivateChildFn, Router } from '@angular/router';
import { UserRole } from '@core/enums';
import { AuthService } from 'src/app/services/auth-service';

export const adminGuard: CanActivateChildFn = (route, state) => {
  const authSevice = inject(AuthService);
  const router = inject(Router);

  if (authSevice.role() == UserRole.Admin) {
    return true;
  }

  router.navigate(['/authentication/login']);
  return false;
};
