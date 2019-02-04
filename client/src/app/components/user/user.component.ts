import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserNameModalContent } from 'src/app/modals/username.modal.content';
import { UserModel } from 'src/app/models/user.model';
import { Observable } from 'rxjs';
import { UserNotFoundException } from 'src/app/exceptions/user.exception';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})

export class UserComponent implements OnInit  {

  userName: string;
  user: Observable<UserModel>;
  hasUserCredentials: boolean;

  constructor(private userService: UserService, private modalService: NgbModal) { 
    this.userService.checkLogin.subscribe(result => this.hasUserCredentials = result);
  }

  ngOnInit() {
    try {
      this.userService.checkUser((result : UserModel) => {
        if (result) {
          this.userName = result.Name
        }
      }); 
    } catch (error) {
       if (error instanceof UserNotFoundException) {
         setTimeout(() => this.openModal('User Info'), 0);
       }
    }
  }

  createUser(username: string) {
    if (username && username !== '') {
      const user = new UserModel();
      user.Name = username;
      this.userService.createUser(user, (result) => {
        if (!result) {
          this.openModal('Looks like the username is invalid. Try again')
        }
        else {
          this.userName = username;
        }
      });
    }
  }

  openModal(title: string) {
    const modalRef = this.modalService.open(UserNameModalContent);
    if (title && title !== '')
      modalRef.componentInstance.title = title;
    modalRef.result.then(result => this.createUser(result));
  }

  logout() {
    this.userService.logout();
  }

}
