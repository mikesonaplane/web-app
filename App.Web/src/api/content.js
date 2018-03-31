import axios from 'axios';

function getContentList(page, max) {
  return axios.get('api/content', {
    baseURL: 'http://localhost:3333',
    params: {
      page,
      max,
    },
  });
}

export default {
  getContentList,
};
