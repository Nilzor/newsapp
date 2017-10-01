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

const getArticle = (id) => {
    const sleepSecs = 1; // Tell our mock server to wait at least 1 sec with the reply, illustrating progress indicator
    return fetch('http://www.nilsenlabs.com/newsapp/getArticle.php?id=' + id + '&sleep=' + sleepSecs, {
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
    getArticleList: getArticleList,
    getArticle: getArticle,
};
export default exp;

