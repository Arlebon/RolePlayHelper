import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { UserRole } from '@core/enums';
import { AuthService } from 'src/app/services/auth-service';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})
export class Navbar {
  private readonly _authService = inject(AuthService);
  UserRole = UserRole;

  constructor(private cdr: ChangeDetectorRef) {}

  isConnected = this._authService.isConnected;
  role = this._authService.role;

  onClickLogout() {
    this._authService.logout();
    this.cdr.markForCheck();
  }
}
