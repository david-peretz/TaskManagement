
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Task } from '../models/task.model';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'https://localhost:44371/api/task';

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<{ $values: User[] }>(`${this.apiUrl}/users`)
      .pipe(
        map(response => response.$values)
      );
  }

  getTasks(): Observable<Task[]> {
    return this.http.get<{ $values: Task[] }>(`${this.apiUrl}/tasks`)
      .pipe(
        map(response => response.$values)
      );
  }

  addTask(task: Task): Observable<Task> {
    return this.http.post<Task>(`${this.apiUrl}/task`, task);
  }

  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/task/${id}`);
  }
}
