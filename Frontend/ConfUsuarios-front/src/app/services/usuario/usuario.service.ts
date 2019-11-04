import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Usuario } from 'src/app/models/UsuarioModel';

@Injectable({
  providedIn: 'root'
})

export class UsuarioService {
  apiEndPoint: string;
  constructor(protected httpClient: HttpClient) {
    this.apiEndPoint = environment.url + 'usuario/';
  }

  public getUsuarios(): Observable<Usuario[]> {
    return this.httpClient.get(this.apiEndPoint).pipe(map((Response: any) => Response));
  }

  public getUsuario(id: number): Observable<Usuario> {
    return this.httpClient.get(`${this.apiEndPoint}${id}`).pipe(map((Response: any) => Response));
  }

  public cadastrarUsuario(usuario: Usuario) {
    return this.httpClient.post(this.apiEndPoint, usuario).pipe();
  }

  public atualizarUsuario(usuario: Usuario) {
    return this.httpClient.put(this.apiEndPoint, usuario).pipe();
  }

  public deletarUsuario(id: number) {
    return this.httpClient.delete(`${this.apiEndPoint}${id}`).pipe();
  }
}
