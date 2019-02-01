import { Injectable } from "@angular/core";
import { HttpService } from './http.service';
import { TaskModel } from '../models/task.model';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class TaskService {

    constructor(public httpService: HttpService) {}

    public getTasks(): Observable<TaskModel[]>
    {
        const url = `${environment.apiUrl}/tasks`;
        return this.httpService.get<TaskModel[]>(url);
    }
}