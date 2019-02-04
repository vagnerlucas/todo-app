import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { disableBindings } from '@angular/core/src/render3';
import { TaskModel } from '../models/task.model';
import { UserNotFoundException } from '../exceptions/user.exception';


@Injectable()
export class HttpService {
    constructor(private http: HttpClient) {}

    private getOptions() {
        
        try {
            const id = sessionStorage.getItem('X-User-Id');
            console.log(id.toString())
            const headers = new HttpHeaders({
                'Content-Type': 'application/json',
                'X-User-Id': id.toString()
            });

            return {
                headers : headers
            };
        } catch (error) {
            throw new UserNotFoundException('Looks like there is nothing at sessionStorage');
        }
    }

    public unsecurePost<T>(url: string, model: T) : Observable<T>
    {
        return this.http.post<T>(url, model)
                        .pipe(map(res => res));
    }

    // public delete<T>(url: string, model: T) : Observable<T> {
    //     const options = this.getOptions();
    //     return this.http.delete<T>(url, model)
    //                .pipe(map(res => res))
    // }

    public post<T>(url: string, model: T) : Observable<T>
    {
        const options = this.getOptions();
        return this.http.post<T>(url, model, options)
                        .pipe(map(res => res));
    }

    public get<T>(url: string) : Observable<T>
    {
        const options = this.getOptions();
        return this.http.get<T>(url, options)
                        .pipe(map(res => res));
    }
}