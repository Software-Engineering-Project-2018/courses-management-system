
export class BaseService {
  public prefixRestUrl = 'http://localhost:50734';
  // public prefixRestUrl = 'https://quanlylophoc.tk';
  protected readonly httpHeader;
  public headerOptions: any;
  constructor() {
    this.headerOptions = {
      headers: new Headers({
        'Content-Type': 'application/json'
        // 'Access-Control-Allow-Origin': '*'
      })
    };
  }
}
