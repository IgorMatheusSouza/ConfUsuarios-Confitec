import { escolaridade } from "./escolaridade.enum";

export class Usuario  {
  public nome: string;
  public sobrenome: string;
  public email: string;
  public dataNascimento: Date;
  public escolaridade: escolaridade;
}
