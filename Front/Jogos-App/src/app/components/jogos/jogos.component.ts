
import { Component, OnInit } from '@angular/core';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { JogoService } from '../../services/jogo.service';
import { Jogo } from '../../models/Jogo';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-jogos',
  templateUrl: './jogos.component.html',
  styleUrls: ['./jogos.component.scss'],
  providers: [JogoService]
})
export class JogosComponent implements OnInit{
  jogo = {} as Jogo;
  public jogos: any = [];
  public jogosFiltrados: Jogo[] = [];
  private _filtro: string='';

  public get filtro(){//pega as inf do inputbusca
    return this._filtro;
  }
  public set filtro(value: string){
    this._filtro = value;
    this.jogosFiltrados = this.filtro ? this.filtrarDados(this.filtro) : this.jogos;
    //filtra se o input for igual jogos filtrados
  }
  filtrarDados(filtrarOs: string): Jogo[]{
    filtrarOs = filtrarOs.toLocaleLowerCase();
    return this.jogos.filter(
      (jogo: { nome: string; }) => jogo.nome.toLocaleLowerCase().indexOf(filtrarOs) !== -1
    )
  }

  constructor(private jogoService: JogoService,
              private router: ActivatedRoute

              ){}

  ngOnInit(): void{
    this.getjogos();
  }

  public carregarJogo(): void {
    const jogoIdParam = this.router.snapshot.paramMap.get('id');
      if(jogoIdParam === null){
        //this.jogoService.getjogosById(+jogoIdParam).subscribe(
        //   (jogo: Jogo) => {
        //   this.jogo = {...jogo};
        //   this.form.patchValue(this.jogo);
        //   },
        //   () => {},
        //   () => {}
        // )
      }

  }

  public getjogos(): void{
    this.jogoService.getjogos().subscribe(
     (_jogos: Jogo[]) => {
      this.jogos = _jogos,
      this.jogosFiltrados = this.jogos; //indicar inicio ao atualizar pagina
     },
     error => console.log(error)
    );
  }
}
