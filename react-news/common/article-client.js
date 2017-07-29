const getArticleList = () => {
    return fetch('http://www.nilsenlabs.com/newsapp/data/latest.json', {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
    .then((response) => response.json())
    .catch((error) => {
        console.error(error);
    });
};

const exp = {
    getArticleList: getArticleList
};
export default exp;

// Fetching article:
// http://www.nilsenlabs.com/newsapp/getArticle.php?id=8yk1E&sleep=2
