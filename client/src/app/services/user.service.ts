import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserModel } from '../models/user.model';
import { map } from 'rxjs/operators';
import { UserNotFoundException } from '../exceptions/user.exception';

@Injectable()
export class UserService {

    checkLogin : BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

    constructor(private httpService: HttpService) {}

    public getUser(): Observable<UserModel>
    {
        const url = `${environment.apiUrl}/user/`;
        const result = this.httpService.get<UserModel>(url);

        result.subscribe(user => {
            if (user) {
                this.checkLogin.next(true);
                return user;
            }
        });

        throw new UserNotFoundException('User not found');
    }

    private registerUser(userId: string) {
        sessionStorage.setItem('X-User-Id', userId);
    }

    public createUser(user: UserModel) 
    {
        const url = `${environment.apiUrl}/user/create`;
        const result = this.httpService.unsecurePost<UserModel>(url, user);
        result.subscribe(user => {
            this.registerUser(user.Id);
            this.checkLogin.next(true);
        });
    }
}