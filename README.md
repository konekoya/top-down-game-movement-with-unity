# Top down game movement in Unity.

### What is this?

This is a quick experiment of using a same sprite asset to create a simple 2D top down movement with Unity.

### Why?

While I was in the process of learning Game development with Unity, I've had noticed that Top-down game movement can be achieved mainly in two ways: one with Unity's Blend Trees and the other with scripting. (There might be more ways to do so :)) So I'm creating this little project in hope to find out best way to work with 2D top-down game movement.

### How to use this?

The project was created using Unity `2021.3.16f1`

Open your UnityHub and load the project from your cloned repo, and open either `Movement with Blend Trees` or `Movement with Code` and run the game.

### The tutorials

I basically followed [this](https://www.youtube.com/watch?v=_iJgw2I0MmI&ab_channel=DaniKrossing) YouTube tutorial for player movement only thur code and [this one](https://www.youtube.com/watch?v=fRpoE4FfJf8&ab_channel=JTAGames) for using Blend Trees.

1. There are more tutorials like this available on YT. You can find out more [here](https://github.com/konekoya/game-dev-links#2d-movement-and-animation)
2. The asset I used in both tutorial is a free asset and is available [here](https://limezu.itch.io/moderninteriors). But you probably won't need to download that as the asset is already imported in the Unity editor

> I've tweaked the tutorial a bit, so the code is more terser and both have the exact same functionality. So it's slightly different from the original ones, you will notice this if you do follow the tutorials

### The result

Okay, personally, I like the idea of doing everything in code when possible instead of UI. This probably has something to do with my previous experience with Xcode and iOS development. But when working with the Blend Tree, you have the advantage of preview your animation transition in Unity Editor, and hide all the complexity of state changing with the UI. While with code, you won't be able to preview the animation and probably need to repeat tweak, compile and preview in the game window back and forth. You will have the complete control over the transition which is easily to maintain and can be reviewed in your version control tool like Git.

### Updates

- Added another project that has an NPC follows the waypoints
