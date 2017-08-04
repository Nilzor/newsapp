import { AsyncStorage } from 'react-native';

// Loads or creates an app state
var state = null;
const KEY = '@NewsApp:state';

export default getAppState = async () => {
    if (state === null) {
        console.log("Loading or creating state...");
        state = await tryLoadFromStorage();
        if (state === null) {
            console.log("Constructing state");
            state = new AppState();
        }
    }
    return state;
}

const tryLoadFromStorage = async () => {
    try {
        const str = await AsyncStorage.getItem(KEY);
        var loadedState = JSON.parse(str);
        var state = new AppState(); // Get the save method on board
        Object.assign(state, loadedState);
        return state;
    } catch (error) {
        console.warn("Error loading state: " + error);
        return null;
    }
};

class AppState {
    currentArticleId = null;

    async save() {
        try {
            const stateStr = JSON.stringify(this);
            console.log("Saving state..." + stateStr);
            await AsyncStorage.setItem(KEY, stateStr);
            console.log("State saved");
        } catch (error) {
            console.err(error);
        }
    }
}