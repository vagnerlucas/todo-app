import { Injectable } from "@angular/core";
import { HttpService } from './http.service';
import { TaskModel } from '../models/task.model';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class TaskService {

    constructor(private httpService: HttpService) {}

    public getTasks(): Observable<TaskModel[]> {
        const url = `${environment.apiUrl}/tasks`;
        return this.httpService.get<TaskModel[]>(url);
    }

    public createTask(task: TaskModel) {
        const url = `${environment.apiUrl}/tasks/create`;
        return this.httpService.post<TaskModel>(url, task);
    }

    public remove(task: TaskModel) {
        const url = `${environment.apiUrl}/tasks/delete/${task.Id}`;
        return this.httpService.delete<TaskModel>(url);
    }

    public markAsDone(task: TaskModel) {
        const url = `${environment.apiUrl}/tasks/done`;
        return this.httpService.post<TaskModel>(url, task);
    }
}