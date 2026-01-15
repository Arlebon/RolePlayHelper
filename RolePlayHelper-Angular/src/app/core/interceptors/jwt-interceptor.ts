import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from 'src/app/services/auth-service';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const tk = authService.token();

  if (tk) {
    const cloneReq = req.clone({
      withCredentials: true,
    });
    return next(cloneReq);
  }

  return next(req);
};
