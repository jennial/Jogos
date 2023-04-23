import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Jogo } from '../models/Jogo';

@Injectable()
export class JogoService {
baseURL = 'https://localhost:5001/api/jogos';
constructor(private http: HttpClient) { }

  public getjogos(): Observable<Jogo[]>{
   return this.http.get<Jogo[]>(this.baseURL);

  }
  public getjogosByNome(nome: string): Observable<Jogo[]>{
    return this.http.get<Jogo[]>(`${this.baseURL}/${nome}/nome`);

   }
   public getjogosById(id: number): Observable<Jogo>{
    return this.http.get<Jogo>(`${this.baseURL}/${id}`);

   }


   public post(jogo: Jogo): Observable<Jogo>{
    return this.http.post<Jogo>(this.baseURL, jogo);

   }
   public put(id: number, jogo: Jogo): Observable<Jogo>{
    return this.http.put<Jogo>(`${this.baseURL}/${id}`, jogo);

   }
   public delete(id: number): Observable<string>{
    return this.http.delete<string>(`${this.baseURL}/${id}`);

   }
}
