
async function makeClient(uniqueChannelId) {
    console.log(`Making channel with ID ${uniqueChannelId}.`);
    // A payload can be sent along with channel connection requests to help with authentication
    const connectPayload = {payload: window.location, wait: true };

    // If the channel has been created this request will be sent to the provider.  If not, the
    // promise will not be resolved or rejected until the channel has been created.
    const clientBus = await fin.InterApplicationBus.Channel.connect(uniqueChannelId, connectPayload);

    console.log(`Connected to channel with ID ${uniqueChannelId}.`);

    clientBus.register('navigate', (payload, identity) => {
        // register a callback for a topic to which the channel provider can dispatch an action
        console.log('Action dispatched by provider: ', JSON.stringify(identity));
        console.log('Payload sent in dispatch: ', JSON.stringify(payload));
        const navigateForward = payload.directionIsForward;
        if (navigateForward) {
            history.forward();
        } else {
            history.back();
        }
    });

    clientBus.register('navigateTo', (payload, identity) => {
        // register a callback for a topic to which the channel provider can dispatch an action
        console.log('Action dispatched by provider: ', JSON.stringify(identity));
        console.log('Payload sent in dispatch: ', JSON.stringify(payload));
        const navigateTo = payload.newUrl;
        window.location.href = navigateTo;
    });
}

window.addEventListener('DOMContentLoaded', async () => {
    if (window !== window.top) {
        // Dont want to add this behaviour to iframes
        return;
    }

    makeClient("NavigationDriver10");
});