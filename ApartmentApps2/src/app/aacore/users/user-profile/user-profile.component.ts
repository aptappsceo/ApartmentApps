import { Component, OnInit } from '@angular/core';
import { UserContext } from "app/aaservice-module/usercontext";
import { UserInfoViewModel } from "app/aaservice-module/aaclient";
import { UserService } from "app/aaservice-module/user.service";

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  userInfo: UserInfoViewModel;
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.RequestUserInfo().then( x => {
      this.userInfo = x;
    });
  }
}
