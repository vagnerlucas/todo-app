import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserModel } from '../models/user.model';
import { map } from 'rxjs/operators';
import { UserNotFoundException, UserCreationException } from '../exceptions/user.exception';

@Injectable()
export class UserService {

    checkLogin: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

    constructor(private httpService: HttpService) { }

    public checkUser(cb: Function): void {
        const url = `${environment.apiUrl}/user/info`;
        const result = this.httpService.get<UserModel>(url);

        result.subscribe(user => {
            if (user) {
                this.checkLogin.next(true);
                cb(user);
            }
        }, (e) =>  { throw new UserNotFoundException('User not found'); });
    }

    private registerUser(userId: string): void {
        sessionStorage.setItem('X-User-Id', userId);
    }

    public logout() : void {
        const url = `${environment.apiUrl}/user/logout`;
        this.httpService.post(url, null).subscribe(_ => {
            sessionStorage.clear();
            this.checkLogin.next(false);
        })
    }

    public createUser(user: UserModel, cb: Function) : void {
        const url = `${environment.apiUrl}/user/create`;

        var request = this.httpService.unsecurePost<UserModel>(url, user);
       
        request.subscribe(user => {
            this.registerUser(user.Id);
            this.checkLogin.next(true);
            cb(true);
        }, (e) => cb(false));
    }
}