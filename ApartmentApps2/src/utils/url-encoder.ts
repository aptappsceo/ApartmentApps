export function Encode(obj : any, prefix : string = null) {
    let str : any[] = [];
    let p : any;
    for(p in obj) {
        if (obj.hasOwnProperty(p)) {
            var k = prefix ? prefix + '[' + p + ']' : p, v = obj[p];
            str.push((v !== null && typeof v === 'object') ?
                Encode(v, k) :
            encodeURIComponent(k) + '=' + encodeURIComponent(v));
        }
    }
    return str.join('&');
}
