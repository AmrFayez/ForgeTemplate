import axios from 'axios'

export default() => {
    return axios.create({
         baseURL: `/api/` , /*https://localhost:44346/api/*/
        withCredentials: false,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
}