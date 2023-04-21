import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-jogos',
  templateUrl: './jogos.component.html',
  styleUrls: ['./jogos.component.scss']
})
export class JogosComponent implements OnInit{

  public jogos: any = [];
  public jogosFiltrados: any = [];
  private _filtro: string='';

  public get filtro(){//pega as inf do inputbusca
    return this._filtro;
  }
  public set filtro(value: string){
    this._filtro = value;
    this.jogosFiltrados = this.filtro ? this.filtrarDados(this.filtro) : this.jogos;
    //filtra se o input for igual jogos filtrados
  }
  filtrarDados(filtrarOs: string):any{
    filtrarOs = filtrarOs.toLocaleLowerCase();
    return this.jogos.filter(
      (jogo: { nome: string; }) => jogo.nome.toLocaleLowerCase().indexOf(filtrarOs) !== -1
    )
  }
//atribui o filtro de busca para #filtrarjogos
 //se o filtrolista for alterado será alterado o filtrarjogos

   // filtrarJogos(filtrarOs: string): any{
     // filtrarOs = filtrarOs.toLocaleLowerCase();
      //return this.jogos.filter(
      //  (jogo: { nome: string; }) => jogo.nome.toLocaleLowerCase().indexOf(filtrarOs) !== -1
     // )
    //}

  constructor(private http: HttpClient){}

  ngOnInit(): void{
    this.getjogos();
  }

  public getjogos(): void{
    this.http.get('https://localhost:5001/api/jogos').subscribe(
     response => {
      this.jogos = response,
      this.jogosFiltrados = this.jogos; //indicar inicio ao atualizar pagina
     },
     error => console.log(error)
    );
  }
}
