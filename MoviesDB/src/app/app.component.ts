import { Component } from '@angular/core';
import { AuthService } from './services/auth/auth.service';
import { PopoverModule } from 'ngx-bootstrap/popover';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'workshop';
  user: any;
  logout: boolean = false;

  constructor(
    private authService: AuthService
  ){
    this.authService.userState.subscribe(user => {
      this.user = user;
    })
  }

  logOut(){
    this.authService.logOut();
    this.logout = true;
  }

}
