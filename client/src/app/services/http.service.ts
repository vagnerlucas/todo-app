import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { disableBindings } from '@angular/core/src/render3';


@Injectable()
export class HttpService {
    constructor(public http: HttpClient) {}

    private getOptions() {
        
        const id = sessionStorage.getItem('X-User-Id');
        
        if (id)
        {
            const headers = new HttpHeaders({
                'Content-Type': 'application/json',
                'X-User-Id': id
            });   
           
            return {
                headers : headers
            };
        }

        throw new Error('Looks like there is nothing at sessionStorage');
    }

    public get<T>(url: string)
    {
        const options = this.getOptions();
        return this.http.get<T>(url, options)
                        .pipe(map(res => res));
    }
}