using UnityEditor;
using UnityEngine;

namespace GG.Editor
{
    /// <summary>
    /// Simple script to export sprites from a sprite sheet after slice using Unity Sprite Editor <br/>
    /// Step by Step to export sprites from a sprite sheet: <br/>
    ///     1. Import your sprite sheet <br/>
    ///     2. Change `Texture Type` to `Sprite (2D and UI)` <br/>
    ///     3. Change `Sprite Mode` to `Multiple` <br/>
    ///     4. Change `Mesh Type` to `Full Rect` <br/>
    ///     5. Turn on `Read/Write` property in `Advanced` section <br/>
    ///     6. Set `Compression` to `None` <br/>
    ///     7. Hit `Apply` to apply all above settings <br/>
    ///     8. Hit `Sprite Editor` to Slice your sheet into multiple sprites then hit `Apply` <br/>
    ///     9. Select sprites you want to export in Asset panel, right click and choose `GG/Export Sprites` <br/>
    ///     10. Choose your output folder and click `Save` <br/>
    /// </summary>
    public class SpriteSheetExporter : MonoBehaviour
    {
        [MenuItem("Assets/GG/Export Sprites")]
        public static void ExportSprites()
        {
            var folder = EditorUtility.OpenFolderPanel("Output folder", "", "");
            foreach (var obj in Selection.objects)
            {
                var sprite = obj as Sprite;
                if (sprite == null) continue;
                var extracted = GetTexture2D(sprite);
                SaveSprite(extracted, folder);
            }
        }

        [MenuItem("Assets/GG/Export Sprites", true)]
        private static bool CanExportSprites()
        {
            return Selection.activeObject is Sprite;
        }

        private static Texture2D GetTexture2D(Sprite sprite)
        {
            var output = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            var r = sprite.textureRect;
            var pixels = sprite.texture.GetPixels((int)r.x, (int)r.y, (int)r.width, (int)r.height);
            output.SetPixels(pixels);
            output.Apply();
            output.name = sprite.texture.name + " " + sprite.name;
            return output;
        }

        private static void SaveSprite(Texture2D tex, string saveToDirectory)
        {
            if (!System.IO.Directory.Exists(saveToDirectory)) System.IO.Directory.CreateDirectory(saveToDirectory);
            System.IO.File.WriteAllBytes(System.IO.Path.Combine(saveToDirectory, tex.name + ".png"), tex.EncodeToPNG());
        }
    }
}