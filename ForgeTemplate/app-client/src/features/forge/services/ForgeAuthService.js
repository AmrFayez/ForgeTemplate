import Api from '../../shared/services/api'
const baseUrl="forge";
export default {
     getAccessTokenAsync(){
     return Api().get(`${baseUrl}/token`);
    }
}